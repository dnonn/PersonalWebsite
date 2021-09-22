import { Grid } from "@mui/material";

import IArea from "../../../../shared/interfaces/area.interface";
import Area from "./area";

type Props = {
  areas: IArea[];
};

export default function AreaGrid(props: Props) {
  const { areas } = props;

  return (
    <Grid container spacing={2}>
      {areas.map((area) => (
        <Grid key={area.route} item xs={12} sm={4}>
          <Area area={area} />
        </Grid>
      ))}
    </Grid>
  );
}
