import axios from 'axios'
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      routes: [],
      collapsed: true,
      searchContent: ''
    }
  },
  mounted() {
    let vm = this
    axios
      .get('/Category/GetAll')
      .then(response => (
        response.data.forEach(function (item) {
          vm.routes.push({ path: '/'.concat(item.name), display: item.name, id: item.id });
        })
      ))
  },
  methods: {
    toggleCollapsed: function (event) {
      this.collapsed = !this.collapsed
    },
    ...mapActions(['setCategory', 'setSearchContent']),
    changeCategory: function (categoryId, categoryName) {
      this.setCategory({
        categoryId: categoryId,
        categoryName: categoryName
      })
    },
    searchPost: function () {
      this.setSearchContent({
        searchContent: this.searchContent
      })
      this.setCategory({
        categoryId: undefined,
        categoryName: "Search with key: '".concat(this.searchContent).concat("'")
      })
      this.$router.replace('/Search')
    },
    clearSearchContent: function () {
      this.searchContent = ''
      this.setSearchContent({
        searchContent: this.searchContent
      })
    }
  }
}
