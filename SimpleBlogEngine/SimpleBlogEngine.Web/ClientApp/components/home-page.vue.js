import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      posts: [],
      bottom: false,
      totalPost: 0,
      getIndexPost: 1,
      amount: 4
    }
  },
  mounted() {
    if (this.$router.currentRoute.path === '/Search') {
      this.addPostsBySearch()
    } else {
      if (this.currentCategoryId === undefined) {
        this.getTopPosts()
      } else {
        this.addPostsByCategory()
      }
    }
  },
  computed: {
    ...mapState({
      currentCategoryId: state => state.categoryId,
      currentCategoryName: state => state.categoryName,
      currentSearchContent: state => state.searchContent
    })
  },
  methods: {
    ...mapActions(['setPostId']),
    changePostId: function (postId) {
      this.setPostId({
        postId: postId
      })
    },
    bottomVisible() {
      const scrollY = window.scrollY
      const visible = document.documentElement.clientHeight
      const pageHeight = document.documentElement.scrollHeight
      const bottomOfPage = visible + scrollY >= pageHeight
      return bottomOfPage || pageHeight < visible
    },
    getTopPosts() {
      let vm = this
      axios
        .get('/Post/GetTop')
        .then(response => (
          response.data.forEach(function (item) {
            vm.posts.push({ path: '/Post', title: item.title, content: item.content, id: item.id })
          })
        ))
    },
    addPostsByCategory() {
      let vm = this
      axios
        .get('/Post/GetByCategory/'.concat(this.currentCategoryId)
          .concat('?getIndex=').concat(this.getIndexPost).concat('&amount=').concat(this.amount))
        .then(response => {
          this.totalPost = response.data.total
          this.getIndexPost = this.getIndexPost + this.amount
          response.data.posts.forEach(function (item) {
            vm.posts.push({ path: '/Post', title: item.title, content: item.content, id: item.id })
          })
        })
    },
    addPostsBySearch() {
      let vm = this
      axios
        .get('/Post/Search?searchContent='.concat(this.currentSearchContent)
          .concat('&getIndex=').concat(this.getIndexPost).concat('&amount=').concat(this.amount))
        .then(response => {
          this.totalPost = response.data.total
          this.getIndexPost = this.getIndexPost + this.amount
          response.data.posts.forEach(function (item) {
            vm.posts.push({ path: '/Post', title: item.title, content: item.content, id: item.id })
          })
        })
    },
    ChangeToSlug(title, postId) {
      var slug

      // Đổi chữ hoa thành chữ thường
      slug = title.toLowerCase()

      // Đổi ký tự có dấu thành không dấu
      slug = slug.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a')
      slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e')
      slug = slug.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i')
      slug = slug.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o')
      slug = slug.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u')
      slug = slug.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y')
      slug = slug.replace(/đ/gi, 'd')
      // Xóa các ký tự đặt biệt
      slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '')
      // Đổi khoảng trắng thành ký tự gạch ngang
      slug = slug.replace(/ /gi, '-')
      // Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
      // Phòng trường hợp người nhập vào quá nhiều ký tự trắng
      slug = slug.replace(/\-\-\-\-\-/gi, '-')
      slug = slug.replace(/\-\-\-\-/gi, '-')
      slug = slug.replace(/\-\-\-/gi, '-')
      slug = slug.replace(/\-\-/gi, '-')
      // Xóa các ký tự gạch ngang ở đầu và cuối
      slug = '@' + slug + '@'
      slug = slug.replace(/\@\-|\-\@|\@/gi, '')
      return slug.concat('_').concat(postId)
    }
  },
  watch: {
    currentSearchContent() {
      this.posts = []
      this.totalPost = 0
      this.getIndexPost = 1
      this.amount = 4
      this.addPostsBySearch()
    },
    bottom() {
      if (this.$router.currentRoute.path === '/Search') {
        this.addPostsBySearch()
      }
      else {
        this.addPostsByCategory()
      }
    }
  },
  created() {
    window.addEventListener('scroll', () => {
      if ((this.currentCategoryId !== undefined || this.$router.currentRoute.path === '/Search') && this.getIndexPost <= this.totalPost) {
        this.bottom = this.bottomVisible()
      }
    })
  }
}
