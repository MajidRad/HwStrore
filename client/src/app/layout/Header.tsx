import {
  AppBar,
  Avatar,
  Box,
  Button,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import { Link as RouterLink } from "react-router-dom";

import { CurrencyBitcoinOutlined, MenuOutlined } from "@mui/icons-material";

import { Container } from "@mui/system";
import React, { useState } from "react";

const Header = () => {
  const [anchorElNav, setaAnchorElNav] = useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);

  const pages = ["Products", "Pricing", "Blog"];
  const settings = ["Profile", "Account", "Dashboard", "Logout"];
  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setaAnchorElNav(event.currentTarget);
  };
  const handleCloseNavMenu = () => {
    setaAnchorElNav(null);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };
  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };
  return (
    <AppBar position="static">
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <CurrencyBitcoinOutlined
            sx={{ display: { xs: "none", md: "flex" }, mr: 1 }}
          />
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              display: { xs: "none", md: "flex" },
              mr: 2,
              fontWeight: 700,
              letterSpacing: "0.1rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            HW STORE
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuOutlined />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{ vertical: "bottom", horizontal: "left" }}
              transformOrigin={{ vertical: "top", horizontal: "left" }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              {pages.map((page) => (
                <MenuItem key={page} onClick={handleCloseNavMenu}>
                  <Typography textAlign="center">{page}</Typography>
                </MenuItem>
              ))}
            </Menu>
          </Box>
          <CurrencyBitcoinOutlined
            sx={{ display: { xs: "flex", md: "none" }, mr: 1 }}
          />
          <Typography
            variant="h6"
            noWrap
            component="a"
            href="/"
            sx={{
              display: { xs: "flex", md: "none" },
              mr: 2,
              flexGrow: 1,
              fontWeight: 700,
              letterSpacing: "0.2rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            HW STORE
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => (
              <Button
                key={page}
                onClick={handleCloseNavMenu}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {page}
              </Button>
            ))}
          </Box>
          <Box sx={{ flexGrow: 0, display: "flex" }}>
            <Button
              component={RouterLink}
              to="/login"
              sx={{ my: 2, color: "white", display: "block" }}
            >
              Login
            </Button>
            <Button
              component={RouterLink}
              to="/register"
              sx={{ my: 2, color: "white", display: "block" }}
            >
              Register
            </Button>
            {/* <Tooltip title="Open Settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar>M</Avatar>
              </IconButton>
            </Tooltip> */}
            {/*          
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
              {settings.map((setting) => (
                <MenuItem onClick={handleCloseUserMenu} key={setting}>
                  <Typography
                    textAlign="center"
                    component={RouterLink}
                    to={setting}
                  >
                    {setting}
                  </Typography>
                </MenuItem>
              ))}
            </Menu> */}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default Header;
