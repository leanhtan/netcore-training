<template>
  <b-navbar toggleable="md" type="dark" variant="info" fixed="top">

  <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

  <b-navbar-brand to="/" @click="changeCategory(undefined, 'News'), clearSearchContent()">
    <icon :icon="['fab', 'blogger-b']"/> Simple Blog Engine
  </b-navbar-brand>

  <b-collapse is-nav id="nav_collapse">
    <b-navbar-nav>
      <b-nav-item v-for="(route, index) in routes" :key="index"  @click="changeCategory(route.id, route.display), clearSearchContent()" :to="route.path">
        {{ route.display }}
      </b-nav-item>
    </b-navbar-nav>

    <!-- Right aligned nav items -->
    <b-navbar-nav class="ml-auto">
      <input id="searchBar" type="text" class="mr-sm-2 form-control form-control-sm" placeholder="Search" v-on:keyup.enter="searchPost()" v-model="searchContent" />
      <b-button size="sm" class="my-2 my-sm-0 mr-sm-2" @click="searchPost()">Search</b-button>
      <b-button v-b-modal.loginModel size="sm">
        Login
      </b-button>
      <!-- Modal Component -->
      <b-modal id="loginModel" title="Login" size="sm">
        <b-container fluid>
          <b-row class="mb-1">
            <b-button variant="warning" class="mx-auto">
              Login with Microsoft
            </b-button>
          </b-row>          
        </b-container>
        <div slot="modal-footer">
        </div>
      </b-modal>
    </b-navbar-nav>
  </b-collapse>
</b-navbar>

</template>

<script src="./nav-menu.vue.js"> </script>
