import { IMagazin } from "./magazin";

export interface IPaginationMagazin {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IMagazin[];
}
