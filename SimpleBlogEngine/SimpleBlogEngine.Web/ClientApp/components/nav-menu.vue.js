import axios from 'axios'

export default {
  data() {
    return {
      routes: [{ path: '/', display: 'News', icon: 'table' }],
      collapsed: true,
    }
  },
  mounted() {
    let vm = this;
    axios
      .get('./Category/GetAll')
      .then(response => (
        response.data.forEach(function (item) {
          vm.routes.push({ path: '/'.concat(item.name), display: item.name, icon: 'align-justify' });
        })
      ));
  },
  methods: {
    toggleCollapsed: function (event) {
      this.collapsed = !this.collapsed
    }
  }
}

