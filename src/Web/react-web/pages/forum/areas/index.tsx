import AreaGrid from "../../../components/areas/area-grid";
import IArea from "../../../shared/interfaces/area.interface";

const DUMMY_AREAS = [
  {
    route: "Martin-Luther-King",
    image: "/images/mlk.jpg",
  } as IArea,
  {
    route: "Martin-Luther-King",
    image: "/images/mlk.jpg",
  } as IArea,
  {
    route: "Martin-Luther-King",
    image: "/images/mlk.jpg",
  } as IArea,
];

export default function AreasPage() {
  return <AreaGrid areas={DUMMY_AREAS}></AreaGrid>;
}
