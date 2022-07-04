import React from "react";
import { useForm, FieldValues } from "react-hook-form";
import { useAppDispatch } from "../../app/store/configureStore";

import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { LockOutlined } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import {
  Grid,
  Box,
  Avatar,
  Typography,
  TextField,
  FormControlLabel,
  Checkbox,
} from "@mui/material";
interface IFormInput {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
  username: string;
}

const Register = () => {
  const dispatch = useAppDispatch();
  const schema = yup.object({
    firstName: yup.string().required(),
    lastName: yup.string().required(),
    username: yup.string().required(),
    email: yup.string().required().email(),
    password: yup.string().required(),
    confirmPassword: yup
      .string()
      .oneOf([yup.ref("password"), null], "password must match"),
  });
  const {
    handleSubmit,
    register,
    formState: { isValid, isSubmitting, errors },
  } = useForm<IFormInput>({ resolver: yupResolver(schema), mode: "all" });
  const submitForm = async (data: FieldValues) => {
    // handleSubmit(data);
  };

  return (
    <Grid
      container
      component="main"
      sx={{ height: "90vh", mt: 2, overflow: "hidden" }}
    >
      <Grid
        item
        xs={false}
        sm={4}
        md={7}
        sx={{
          backgroundImage: `url(${process.env.PUBLIC_URL + "/images/2.jpg"})`,
          height: "100%",
          position: "relative",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          backgroundSize: "cover",
        }}
      >
        <Box
          sx={{
            background:
              "linear-gradient(to top, rgba(0,0,0,0.2), rgba(0,0,0,0.1) 500px), linear-gradient(to top, rgba(0,0,0,0.6), rgba(0,0,0,0.1) 300px)",
            height: "100%",
            zIndex: (theme) => theme.zIndex.drawer + 1,
          }}
        ></Box>
      </Grid>
      <Grid item xs={12} sm={8} md={5} position="relative">
        <Box
          sx={{
            position: "absolute",
            top: "10%",
            my: 8,
            mx: 4,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyItems: "center",
          }}
        >
          <Avatar>
            <LockOutlined />
          </Avatar>
          <Typography variant="h4" component="h1">
            Sign Up
          </Typography>

          <Box
            component="form"
            onSubmit={handleSubmit(submitForm)}
            sx={{ ".MuiTextField-root": { my: 1 } }}
          >
            <TextField
              label="FirstName"
              fullWidth
              autoComplete="firstName"
              {...register("firstName")}
              helperText={errors.firstName?.message}
            />
            <TextField
              label="Last Name"
              fullWidth
              autoComplete="lastName"
              {...register("firstName")}
              helperText={errors.firstName?.message}
            />
            <TextField
              label="Email"
              {...register("email")}
              margin="normal"
              fullWidth
              autoComplete="email"
              autoFocus
              helperText={errors.email?.message}
            />
            <TextField
              label="Password"
              fullWidth
              type="password"
              autoComplete="current-password"
              {...register("password")}
              helperText={errors.password?.message}
            />
            <TextField
              label="Confirm Password"
              fullWidth
              type="password"
              autoComplete="current-password"
              {...register("confirmPassword")}
              helperText={errors.confirmPassword?.message}
            />
            <TextField
              label="User Name"
              fullWidth
              {...register("username")}
              helperText={errors.username?.message}
            />

            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember Me"
            />
            <LoadingButton
              loading={isSubmitting}
              disabled={!isValid}
              variant="contained"
              fullWidth
            >
              Sign In
            </LoadingButton>
          </Box>
        </Box>
      </Grid>
    </Grid>
  );
};
export default Register;
