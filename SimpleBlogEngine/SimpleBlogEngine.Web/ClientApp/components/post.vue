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
            <b-form-input required="" placeholder="Name"/>
          </b-form-group>
          <b-form-group>
            <b-form-textarea v-model="text" required="" :rows="5" placeholder="Leave a comment"/>
          </b-form-group>
          <b-button variant="primary">Post</b-button>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>
<script src="./post.vue.js" />
