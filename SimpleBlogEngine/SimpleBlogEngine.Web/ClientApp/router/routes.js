import HomePage from 'components/home-page'
import Post from 'components/post'

export const routes = [
  { path: '/Search', name: 'search', component: HomePage },
  { path: '/Post/:postName', name: 'post', component: Post },
  { path: '/*', name: 'home', component: HomePage }
]
