import axios from 'axios'
import { mapActions, mapState } from 'vuex'

export default {
  data() {
    return {
      posts: [],
      newPosts: [],

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
          .get('./Post/GetByCategory/'.concat(this.currentCategoryId))
          .then(response => (
            response.data.forEach(function (item) {
              vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
            })
          ));
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
    }
  },
  watch: {
    currentSearchContent(newValue) {
      let vm = this;
      this.posts= [];
      axios
        .get('./Post/Search?searchContent='.concat(newValue))
        .then(response => (
          response.data.forEach(function (item) {
            vm.posts.push({ path: "/Post", title: item.title, content: item.content, id: item.id });
          })
        ));
    }
  }
}
