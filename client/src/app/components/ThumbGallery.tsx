import React, { useRef, useState } from "react";
// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";

// Import Swiper styles
import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import "swiper/css/thumbs";
import type { Swiper as SwiperType } from "swiper";
import "./styles.css";
import { Image } from "../model/Image";
// import required modules
import { FreeMode, Navigation, Thumbs } from "swiper";

interface Props {
  images: Image[] | undefined;
}
export default function ThumbGallery({ images }: Props) {
  const [thumbsSwiper, setThumbsSwiper] = useState<SwiperType | null>(null);

  return (
    <>
      <Swiper
        style={{ zIndex: -1 }}
        aria-disabled={true}
        loop={true}
        spaceBetween={10}
        navigation={true}
        thumbs={{
          swiper: thumbsSwiper && !thumbsSwiper.destroyed ? thumbsSwiper : null,
        }}
        modules={[FreeMode, Navigation, Thumbs]}
        className="mySwiper2"
      >
        {images &&
          images.map((image) => (
            <SwiperSlide key={image.id}>
              <img src={`/${image.path}.jpg`} />
            </SwiperSlide>
          ))}
      </Swiper>
      <Swiper
        onSwiper={setThumbsSwiper}
        spaceBetween={10}
        slidesPerView={4}
        freeMode={true}
        watchSlidesProgress={true}
        modules={[FreeMode, Navigation, Thumbs]}
        className="mySwiper"
      >
        {images &&
          images.map((image) => (
            <SwiperSlide key={image.id}>
              <img src={`/${image.path}.jpg`} />
            </SwiperSlide>
          ))}
      </Swiper>
    </>
  );
}
