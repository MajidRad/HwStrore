import { LockOutlined } from "@mui/icons-material";
import {
  Avatar,
  Backdrop,
  Box,
  Checkbox,
  FormControlLabel,
  Grid,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { useForm, FieldValues, FieldPathValues } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useAppDispatch } from "../../app/store/configureStore";
import { signInUser } from "./accountSlice";
import { useLocation, useNavigate } from "react-router-dom";
import { LoadingButton } from "@mui/lab";
interface IFormInputs {
  email: string;
  password: string;
}
type LocationProps = {
  state: {
    from: Location;
  };
};
const Login = () => {
  let location = useLocation() as unknown as LocationProps;

  const navigate = useNavigate();
  const schema = yup.object({
    email: yup.string().required(),
    password: yup.string().required(),
  });
  const dispatch = useAppDispatch();
  const {
    handleSubmit,
    register,
    formState: { isSubmitting, errors, isValid },
  } = useForm<IFormInputs>({ resolver: yupResolver(schema), mode: "all" });
  const submitForm = async (data: FieldValues) => {
    await dispatch(signInUser(data));
    let from = location.state?.from?.pathname || "/";
    navigate(from, { replace: true });
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
          backgroundImage: `url(${process.env.PUBLIC_URL + "/images/1.jpg"})`,
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
            top: "20%",
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
            Sign In
          </Typography>

          <Box component="form" onSubmit={handleSubmit(submitForm)}>
            <TextField
              {...register("email")}
              margin="normal"
              fullWidth
              autoComplete="email"
              autoFocus
              helperText={errors.email?.message}
              sx={{ my: 2 }}
            />
            <TextField
              fullWidth
              type="password"
              autoComplete="current-password"
              {...register("password")}
              helperText={errors.password?.message}
            />
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="Remember Me"
            />
            <LoadingButton
              loading={isSubmitting}
              disabled={!isValid}
              variant="contained"
              type="submit"
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

export default Login;
