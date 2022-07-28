import { Box, Pagination, Stack, Typography } from "@mui/material";
import React, { useState } from "react";

import { MetaData } from "../model/MetaData";

interface Props {
  metaData: MetaData;
  onPageChange: (page: number) => void;
}
const PaginationRounded = ({ metaData, onPageChange }: Props) => {
  const { currentPage, totalItems, totalPages, itemsPerPage } = metaData;
  const [pageNumber, setPageNumber] = useState(currentPage);

  function handlePageChange(page: number) {
    setPageNumber(page);
    onPageChange(page);
  }
  return (
    <Stack spacing={2} sx={{ mx: "auto", my: 2 }}>
      <Box display="flex" alignItems="center" justifyContent="space-between">
        <Typography>
          Displaying {(currentPage - 1) * itemsPerPage + 1}-
          {currentPage * itemsPerPage > totalItems
            ? totalItems
            : currentPage * itemsPerPage}{" "}
          of {totalItems} items
        </Typography>
        <Pagination
          page={pageNumber}
          onChange={(e, page) => handlePageChange(page)}
          count={totalPages}
          size="large"
          color="secondary"
          variant="outlined"
          shape="rounded"
        />
      </Box>
    </Stack>
  );
};

export default PaginationRounded;
