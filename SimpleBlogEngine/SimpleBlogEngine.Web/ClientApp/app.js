import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import BootstrapVue from 'bootstrap-vue'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

Vue.use(BootstrapVue);

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
