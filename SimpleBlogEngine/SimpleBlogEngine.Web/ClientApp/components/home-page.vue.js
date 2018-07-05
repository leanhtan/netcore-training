import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      posts: [],
      newPosts: []
    }
  },
  mounted() {
    let vm = this;
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
        .get('./Post/GetByCategory/'.concat(this.currentCategoryId))
        .then(response => (
          response.data.forEach(function (item) {
            vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        ));
    }
  },
  computed: {
    ...mapState({
      currentCategoryId: state => state.categoryId,
      currentCategoryName: state => state.categoryName,
      currentSearchContent() { return this.$store.state.searchContent }
    })
  },
  methods: {
    ...mapActions(['setPostId']),
    changePostId: function (postId) {
      this.setPostId({
        postId: postId,
      })
    }
  },
  watch: {
    currentSearchContent(newValue) {
      let vm = this;
      this.$set(this.posts, '', []);
      console.log(newValue);
      axios
        .get('./Post/GetByCategory/'.concat(newValue))
        .then(response => (
          response.data.forEach(function (item) {
            vm.$set(vm.posts, '', { path: "/Post", title: item.title, content: item.content, id: item.id });
            //vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        ));
    }
  }
}
