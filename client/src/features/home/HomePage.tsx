import { Box, SxProps } from "@mui/material";
import { height } from "@mui/system";
import React from "react";

const HomePage = () => {
  const glassyStyle: SxProps = {
    bgcolor: "rgba(233,222,250,0.1)",
    backdropFilter: "blur(20px)",
    borderRadius: "10px",
    position: "absolute",
    zIndex: 1,
  };
  return (
    <>
      <Box
        sx={{
          ...glassyStyle,
          height: "200px",
          width: "200px",
        }}
      ></Box>
      <Box
        sx={{
          my: "10%",
          height: "100px",
        }}
      ></Box>
    </>
  );
};

export default HomePage;
