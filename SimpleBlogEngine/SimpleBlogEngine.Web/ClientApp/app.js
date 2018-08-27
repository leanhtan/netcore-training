import Vue from 'vue'
import axios from 'axios'
import BootstrapVue from 'bootstrap-vue'
import { sync } from 'vuex-router-sync'
import { FontAwesomeIcon } from './icons'
import store from './store'
import router from './router/index'
import App from 'components/app-root'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

Vue.use(BootstrapVue)

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
