import HomePage from 'components/home-page'
import Post from 'components/post'

export const routes = [
  { path: '/Post', component: Post },
  { path: '/*', component: HomePage },
]
