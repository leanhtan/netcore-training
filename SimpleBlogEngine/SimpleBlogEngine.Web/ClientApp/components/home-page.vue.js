import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      posts: [],
      bottom: false,
      totalPost: 0,
      getIndexPost: 1,
      amount: 6,
    }
  },
  mounted() {
    let vm = this;
    if (this.$router.currentRoute.path === "/Search") {
      let vm = this;
      axios
        .get('./Post/Search?searchContent='.concat(this.currentSearchContent))
        .then(response => (
          response.data.forEach(function (item) {
            vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        ));
    } else {
      if (this.currentCategoryId === undefined) {
        axios
          .get('./Post/GetTop')
          .then(response => (
            response.data.forEach(function (item) {
              vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
            })
          ));
      }
      else {
        axios
          .get('./Post/GetByCategory/'.concat(this.currentCategoryId)
            .concat("?getIndex=").concat(this.getIndexPost).concat("&amount=").concat(this.amount))
          .then(response => {
            this.totalPost = response.data.total;
            this.getIndexPost = this.getIndexPost + this.amount;
            response.data.posts.forEach(function (item) {
              vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
            })
          });
      }
    }
  },
  computed: {
    ...mapState({
      currentCategoryId: state => state.categoryId,
      currentCategoryName: state => state.categoryName,
      currentSearchContent: state => state.searchContent,
      currentSearchContent() { return this.$store.state.searchContent }
    })
  },
  methods: {
    ...mapActions(['setPostId']),
    changePostId: function (postId) {
      this.setPostId({
        postId: postId,
      })
    },
    bottomVisible() {
      const scrollY = window.scrollY
      const visible = document.documentElement.clientHeight
      const pageHeight = document.documentElement.scrollHeight
      const bottomOfPage = visible + scrollY >= pageHeight
      return bottomOfPage || pageHeight < visible
    },
    addBeer() {
      let vm = this;
      axios
        .get('./Post/GetByCategory/'.concat(this.currentCategoryId)
          .concat("?getIndex=").concat(this.getIndexPost).concat("&amount=").concat(this.amount))
        .then(response => {
          this.totalPost = response.data.total;
          this.getIndexPost = this.getIndexPost + this.amount;
          response.data.posts.forEach(function (item) {
            vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        });
    }
  },
  watch: {
    currentSearchContent(newValue) {
      let vm = this;
      this.posts = [];
      axios
        .get('./Post/Search?searchContent='.concat(newValue))
        .then(response => (
          response.data.forEach(function (item) {
            vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        ));
    },
    bottom(bottom) {
      this.addBeer();
    }
  },
  created() {
    window.addEventListener('scroll', () => {
      if (this.currentCategoryId != undefined && this.getIndexPost <= this.totalPost) {
        this.bottom = this.bottomVisible()
      }
    });
  }
}
