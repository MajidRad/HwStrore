import { MergeTypeOutlined, Sd, StarRate } from "@mui/icons-material";
import {
  Box,
  Button,
  Divider,
  Grid,
  IconButton,
  Paper,
  Rating,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchProductDetail, productSelector } from "./productSlice";
import { grey, teal } from "@mui/material/colors";
import { AddCircleOutline, RemoveCircleOutline } from "@mui/icons-material";
import ThumbGallery from "../../app/components/ThumbGallery";

const ProductDetails = () => {
  const { id } = useParams<{ id: string }>();
  const productDetails = useAppSelector((state) =>
    productSelector.selectById(state, id ? id : -1)
  );
  const dispatch = useAppDispatch();
  type Props = { children?: JSX.Element | JSX.Element[] };
  useEffect(() => {
    if (id !== undefined) {
      dispatch(fetchProductDetail(parseInt(id)));
    }
  }, [dispatch]);

  const Item: React.FC<Props> = ({ children }) => {
    return <Paper sx={{ backgroundColor: grey[400] }}>{children}</Paper>;
  };
  const [qty, setQty] = useState(0);
  return (
    <Grid container sx={{ my: 2 }} columnSpacing={2} rowSpacing={4}>
      <Grid item xs={12} md={4}>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "space-between",
            height: "100%",
          }}
        >
          <Typography variant="h5" color="secondary">
            {productDetails?.brand?.name.toUpperCase()}
          </Typography>
          <Divider variant="fullWidth" />
          <Typography variant="h6">{productDetails?.name}</Typography>
          <Typography variant="body1" color="red">
            {productDetails && productDetails?.quantity > 0
              ? "Available In Store"
              : "Not Available In Store"}
          </Typography>
          <Divider variant="middle" />
          <Rating
            name="read-only"
            value={3}
            readOnly
            sx={{ justifyContent: "center" }}
          />
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-around",
              p: 2,
              borderRadius: 2,
              background: `${teal[50]}`,
            }}
          >
            <Typography variant="h6">{productDetails?.price}$</Typography>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
              }}
            >
              <IconButton>
                <AddCircleOutline />
              </IconButton>
              <Typography sx={{ mx: 2 }}>{qty}</Typography>
              <IconButton>
                <RemoveCircleOutline />
              </IconButton>
            </Box>
          </Box>
          <Button fullWidth variant="contained">
            Add To Basket
          </Button>
        </Box>
      </Grid>
      <Grid item xs={12} md={4}>
        <Box>
          <Typography variant="h5">{productDetails?.name}</Typography>
          <Typography variant="body1" color="GrayText" sx={{ my: 2 }}>
            {productDetails?.description}
          </Typography>
        </Box>
      </Grid>
      <Grid item xs={12} md={4}>
        <ThumbGallery images={productDetails?.images} />
      </Grid>
      {/* <Grid item xs={12}>
        <Item>
          <div>Similar product</div>
        </Item>
      </Grid> */}
      <Grid item xs={12}>
        <Divider variant="middle" />
        <Typography variant="h4">Product Specification</Typography>
        <Table>
          <TableBody>
            {productDetails?.specifications?.map((item) => (
              <>
                <TableRow>
                  <TableCell>{item.specLabel}</TableCell>
                  <TableCell>{item.specValue}</TableCell>
                </TableRow>
              </>
            ))}
          </TableBody>
        </Table>
      </Grid>
    </Grid>
  );
};

export default ProductDetails;
