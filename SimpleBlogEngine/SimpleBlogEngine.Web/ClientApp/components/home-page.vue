<template>
  <b-container>
    <h1>{{currentCategoryName}}</h1>
    <b-row style="margin-top: 25px;">
      <b-card-group columns="">
        <div v-for="(post, index) in posts">
          <b-card :title="post.title"
            img-src="https://picsum.photos/600/300/?image=25"
            img-alt="Image"
            img-top=""
            tag="article"
            style="max-width: 19rem; margin-right: 15px;"
            class="mb-2">
            <p class="card-text">
              {{post.content}}
            </p>
            <b-button :to="post.path" variant="primary" @click="changePostId(post.id)">Details</b-button>
          </b-card>
        </div>
      </b-card-group>
    </b-row>
  </b-container>
</template>

<script src="./home-page.vue.js" />

<style>
</style>
