import {
  Avatar,
  IconButton,
  Menu,
  MenuItem,
  Tooltip,
  Typography,
} from "@mui/material";
import { Link as RouterLink, useNavigate } from "react-router-dom";
import React, { useState } from "react";
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import { signOut } from "../../features/account/accountSlice";
import { Logout } from "@mui/icons-material";
import { clearBasket } from "../../features/basket/basketSlice";

const SignedInMenu = () => {
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);
  const settings = ["Profile", "Orders", "Logout"];
  const dispatch = useAppDispatch();
  const { User } = useAppSelector((state) => state.account);

  const navigate = useNavigate();
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };
  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };
  const logOut = () => {
    dispatch(signOut());
    dispatch(clearBasket());
    navigate("/");
  };
  return (
    <>
      <Tooltip title="Open Settings">
        <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
          <Avatar>{User?.email.charAt(0)}</Avatar>
        </IconButton>
      </Tooltip>

      <Menu
        sx={{ mt: "45px" }}
        id="menu-appbar"
        anchorEl={anchorElUser}
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        keepMounted
        transformOrigin={{
          vertical: "top",
          horizontal: "right",
        }}
        open={Boolean(anchorElUser)}
        onClose={handleCloseUserMenu}
      >
        <MenuItem onClick={handleCloseUserMenu}>Profile</MenuItem>
        <MenuItem onClick={handleCloseUserMenu}>My Orders</MenuItem>
        <MenuItem onClick={logOut}>Logout</MenuItem>
      </Menu>
    </>
  );
};

export default SignedInMenu;
