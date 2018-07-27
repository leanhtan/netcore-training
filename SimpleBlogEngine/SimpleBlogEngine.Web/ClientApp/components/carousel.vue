<template>
  <b-carousel id="carousel1"
                            style="text-shadow: 1px 1px 2px #333;"
                            controls=""
                            indicators=""
                            background="#ababab"
                            :interval="4000"
                            img-width="1024"
                            img-height="200">

    <!-- Text slides with image -->
    <b-carousel-slide caption="Northrop Frye"
                      text="The most technologically efficient machine that man has ever invented is the book."
                      img-src="https://picsum.photos/1024/200/?image=2">
    </b-carousel-slide>
    <b-carousel-slide caption="Thomas Edison"
                      text="It has become appallingly obvious that our technology has exceeded our humanity."
                      img-src="https://picsum.photos/1024/200/?image=26">
    </b-carousel-slide>
    <b-carousel-slide caption="Albert Einstein"
                      text="Nulla vitae elit libero, a pharetra augue mollis interdum.It has become appallingly obvious that our technology has exceeded our humanity."
                      img-src="https://picsum.photos/1024/200/?image=20">
    </b-carousel-slide>
    <b-carousel-slide caption="Elbert Hubbard"
                      text="One machine can do the work of fifty ordinary men. No machine can do the work of one extraordinary man."
                      img-src="https://picsum.photos/1024/200/?image=39">
    </b-carousel-slide>

    <!-- Slides with custom text -->
  </b-carousel>
</template>
