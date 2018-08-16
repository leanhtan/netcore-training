<template>
  <div>
    <h1 class="my-3">{{post.title}}</h1>
    <b-alert show="">{{post.content}}</b-alert>
    <hr/>
    <b-row>
      <b-col cols="12" md="8">
        <b-card bg-variant="light">
          <b-form-group vertical=""
                breakpoint="lg"
                label="Comment"
                label-size="lg"
                label-class="font-weight-bold pt-0">
            <b-form-input required="" placeholder="Name" v-model="comment.name"/>
          </b-form-group>
          <b-form-group>
            <b-form-textarea v-model="comment.content" required="" :rows="5" placeholder="Leave a comment"/>
          </b-form-group>
          <b-button variant="primary" @click="postComment()">Post</b-button>
        </b-card>
      </b-col>
    </b-row>
    <hr v-if="comments.length > 0"/>
    <div v-for="(comment) in comments" :key="comment.id" class="mb-2">
      <b-card bg-variant="light">
        <div class="float-right">
          <i>{{comment.addedDate}}</i>
        </div>
        <h5 variant="primary">
          <icon :icon="['fas', 'user']"/> {{comment.name}}
        </h5>
        <p class="card-text">{{comment.content}}</p>
      </b-card>
    </div>
  </div>
</template>
<script src="./post.vue.js" />
