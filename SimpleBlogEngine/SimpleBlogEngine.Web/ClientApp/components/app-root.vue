<template>
    <div id="app" class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <nav-menu></nav-menu>
            </div>
            <div class="col-sm-9">
              <router-view :key="$route.fullPath"></router-view>
            </div>
        </div>
    </div>
</template>

<script src="./app-root.vue.js"/>
