import axios from 'axios'

export default {
  data() {
    return {
      posts: []
    }
  },
  mounted() {
    let vm = this;
    axios
      .get('./Post/GetTop')
      .then(response => (
        response.data.forEach(function (item) {
          vm.posts.push({ id: "/Post/".concat(item.id), title: item.title, content: item.content });
        })
      ));
  }
}
