<template>
  <b-container>
    <b-row style="margin-top: 25px;">
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
          <b-button :href="post.id" variant="primary">Details</b-button>
        </b-card>
      </div>
    </b-row>
  </b-container>
</template>

<script src="./home-page.vue.js" />

<style>
</style>
