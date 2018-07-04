// Official documentation available at: https://github.com/FortAwesome/vue-fontawesome
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { fab } from '@fortawesome/free-brands-svg-icons'

// If not present, it won't be visible within the application. Considering that you
// don't want all the icons for no reason. This is a good way to avoid importing too many
// unnecessary things.
library.add(fas, fab)

export {
  FontAwesomeIcon
}
