<template>
    <div class="main-nav">
        <nav class="navbar navbar-expand-md navbar-dark bg-dark">
            <input id="searchBar" type="text" class="textbox" placeholder="Search" v-on:keyup.enter="searchPost()" v-model="searchContent"/>
            <button class="navbar-toggler" type="button" @click="toggleCollapsed">
                <span class="navbar-toggler-icon"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <div @click="changeCategory(undefined, 'News'), clearSearchContent()">
              <router-link class="navbar-brand" to="/"><icon :icon="['fab', 'blogger-b']"/> Simple Blog Engine</router-link>
            </div>  
            <transition name="slide">
                <div :class="'collapse navbar-collapse' + (!collapsed ? ' show':'')" v-show="!collapsed">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item" v-for="(route, index) in routes" :key="index"  @click="changeCategory(route.id, route.display), clearSearchContent()">
                            <router-link :to="route.path" exact-active-class="active">
                                <icon :icon="route.icon" class="mr-2" /><span>{{ route.display }}</span> 
                            </router-link>
                        </li>
                    </ul>
                </div>
            </transition>
        </nav>
    </div>
</template>

<script src="./nav-menu.vue.js"> </script>

<style scoped>
    .slide-enter-active, .slide-leave-active {
    transition: max-height .35s
    }
    .slide-enter, .slide-leave-to {
    max-height: 0px;
    }

    .slide-enter-to, .slide-leave {
    max-height: 20em;
    }
</style>
