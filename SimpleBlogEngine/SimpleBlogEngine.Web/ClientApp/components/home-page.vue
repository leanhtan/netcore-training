<template>
  <div>
    <h1>{{currentCategoryName}}</h1>
    <div style="margin-top: 25px;">
      <b-card-group columns="">
        <div v-for="(post, index) in posts" :key="post.id">
          <b-card :title="post.title"
            img-src="https://picsum.photos/600/300/?image=885"
            img-alt="Image"
            img-top=""
            tag="article"
            style="max-width: 25rem; margin-right: 15px;"
            class="mb-2">
            <p class="card-text">
              {{post.content}}
            </p>
            <b-button :to="{name: 'post', params: {postName: ChangeToSlug(post.title, post.id)}}" variant="info" @click="changePostId(post.id)">Chi tiết</b-button>
          </b-card>
        </div>
      </b-card-group>
    </div>
  </div>
</template>

<script src="./home-page.vue.js" />

<style>
</style>
