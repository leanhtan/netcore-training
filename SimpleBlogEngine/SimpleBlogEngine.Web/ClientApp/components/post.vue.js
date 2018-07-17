import axios from 'axios'
import { mapState } from 'vuex'

export default {
  data() {
    return {
      post: {
        title: '',
        content: ''
      }
    }
  },
  mounted() {
    let vm = this;
    if (this.currentPostId != undefined) {
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
