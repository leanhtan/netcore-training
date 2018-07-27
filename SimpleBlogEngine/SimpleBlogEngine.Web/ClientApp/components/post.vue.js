import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      post: {
        title: '',
        content: ''
      },
      text: ''
    }
  },
  mounted() {
    if (this.currentPostId == undefined) {
      this.changePostId(this.$router.currentRoute.path.split("_")[1]);
    }
    this.getPost();
  }, methods: {
    ...mapActions(['setPostId']),
    changePostId: function (postId) {
      this.setPostId({
        postId: postId,
      })
    },
    getPost() {
      let vm = this;
      axios
        .get('/Post/Get/'.concat(this.currentPostId))
        .then(response => (
          vm.post.title = response.data.title,
          vm.post.content = response.data.content
        )
        );
    }
  },
  computed: {
    ...mapState({
      currentPostId: state => state.postId,
    })
  }
}
