import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      post: {
        title: '',
        content: ''
      },
      comment: {
        name: '',
        content: ''
      },
      comments: []
    }
  },
  mounted() {
    if (this.currentPostId === undefined) {
      this.changePostId(this.$router.currentRoute.path.split('_')[1])
    }
    this.getPost()
    this.getComments()
  },
  methods: {
    ...mapActions(['setPostId']),
    changePostId: function (postId) {
      this.setPostId({
        postId: postId
      })
    },
    getPost() {
      let vm = this
      axios
        .get('/Post/Get/'.concat(this.currentPostId))
        .then(response => {
          vm.post.title = response.data.title
          vm.post.content = response.data.content
        }
        )
    },
    postComment() {
      let vm = this
      axios
        .post('/Comment/AddComment', {
          Id: 0,
          Name: vm.comment.name,
          Content: vm.comment.content,
          PostId: this.currentPostId
        })
        .then(response => {
          vm.comment.name = ''
          vm.comment.content = ''
          this.getComments()
        }
        )
    },
    getComments() {
      let vm = this
      vm.comments = []
      axios
        .get('/Comment/GetByPost/'.concat(this.currentPostId))
        .then(response => (
          response.data.forEach(function (item) {
            vm.comments.push({ name: item.name, content: item.content, addedDate: item.addedDate })
          })
        )
        )
    }
  },
  computed: {
    ...mapState({
      currentPostId: state => state.postId
    })
  }
}
