import {
  AppBar,
  Avatar,
  Box,
  Button,
  IconButton,
  Menu,
  MenuItem,
  SxProps,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";

import { Link as RouterLink } from "react-router-dom";

import {
  CurrencyBitcoinOutlined,
  Height,
  MenuOutlined,
} from "@mui/icons-material";

import { Container } from "@mui/system";
import React, { useState } from "react";
import { useAppSelector } from "../store/configureStore";
import SignedInMenu from "./SignedInMenu";

const Header = () => {
  const [anchorElNav, setaAnchorElNav] = useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);

  const pages = ["Products", "Pricing", "Blog"];
  const { User } = useAppSelector((state) => state.account);
  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setaAnchorElNav(event.currentTarget);
  };
  const handleCloseNavMenu = () => {
    setaAnchorElNav(null);
  };
  const glassyStyle: SxProps = {
    bgcolor: "rgba(233,222,250,0.3)",
    backdropFilter: "blur(15px)",
    // boxShadow: "none",
    position: "sticky",
    zIndex: 1,
  };
  return (
    <AppBar elevation={1} sx={{ ...glassyStyle }}>
      <Container
        maxWidth="xl"
        sx={{
          background:
            "linear-gradient(180deg, rgba(44,62,80,0.4) 0%, rgba(189,195,199,0.2) 100%);",
        }}
      >
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
                component={RouterLink}
                to={page}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {page}
              </Button>
            ))}
          </Box>
          {User ? (
            <SignedInMenu />
          ) : (
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
            </Box>
          )}
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default Header;
