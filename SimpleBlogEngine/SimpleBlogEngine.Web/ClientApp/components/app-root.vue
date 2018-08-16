<template>
    <b-container id="app">
      <b-row>
        <b-col>
          <nav-menu></nav-menu>
        </b-col>
      </b-row>
      <b-row>
          <b-col style="margin-top: 70px;">
            <carousel></carousel>
            <router-view :key="$route.fullPath"></router-view>
          </b-col>
      </b-row>
      <hr/>
      <footer>
        <div class="bg-light text-dark p-2">
          <div class="float-right">
            <a href="https://www.linkedin.com/in/tan-le-anh/" class="text-dark" target="_blank">
              <icon :icon="['fab', 'linkedin']" size="lg"/>
            </a>
            <a href="https://www.facebook.com/leanhtan911205" class="text-dark" target="_blank">
              <icon :icon="['fab', 'facebook-square']" size="lg"/>
            </a>
          </div>
          <p>
            A website created base on .NET Core and Vue.js
            </br>
            Design by Tan Le Anh - Senior Software Engineer - NashTech
          </p>
          <i>
            &copy; 2018 Simple Blog Engine
          </i>
        </div>
      </footer>
    </b-container>
</template>

<script src="./app-root.vue.js"/>
