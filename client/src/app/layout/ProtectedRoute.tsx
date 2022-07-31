import { ComponentType } from "react";
import { Navigate, Route, RouteProps, useLocation } from "react-router-dom";
import { JsxElement } from "typescript";
import { useAppSelector } from "../store/configureStore";

export default function ProtectedRoute({
  children,
}: {
  children: JSX.Element;
}) {
  const { User } = useAppSelector((state) => state.account);
  let location = useLocation();
  if (!User) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }
  return children;
}
