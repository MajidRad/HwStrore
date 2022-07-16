import { AxiosError } from "axios";

type OverrideAxiosErrorResponse = Omit<AxiosError, "response"> & {
  overrideField: response;
};
type response = {
  response: {
    data: {
      title: string;
      error?: string;
      errors?: string[];
    };
    status: number;
  };
};

export interface ErrorResponse extends OverrideAxiosErrorResponse {
  response: {
    data: {
      title: string;
      error?: string;
      errors?: string[];
    };
    status: number;
  };
}
