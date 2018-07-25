import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_CATEGORY = 'MAIN_SET_CATEGORY'
const MAIN_SET_POSTID = 'MAIN_SET_POSTID'
const MAIN_SET_SEARCHCONTENT = 'MAIN_SET_SEARCHCONTENT'

// STATE
const state = {
  categoryId: undefined,
  categoryName: 'News',
  postId: undefined,
  searchContent: "",
}

// MUTATIONS
const mutations = {
  [MAIN_SET_CATEGORY](state, obj) {
    state.categoryId = obj.categoryId
    state.categoryName = obj.categoryName
  },
  [MAIN_SET_POSTID](state, obj) {
    state.postId = obj.postId
  },
  [MAIN_SET_SEARCHCONTENT](state, obj) {
    state.searchContent = obj.searchContent
  }
}

// ACTIONS
const actions = ({
  setCategory({ commit }, obj) {
    commit(MAIN_SET_CATEGORY, obj)
  },
  setPostId({ commit }, obj) {
    commit(MAIN_SET_POSTID, obj)
  },
  setSearchContent({ commit }, obj) {
    commit(MAIN_SET_SEARCHCONTENT, obj)
  }
})

export default new Vuex.Store({
  state,
  mutations,
  actions
})
