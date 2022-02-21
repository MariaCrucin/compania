export interface IFurnizor {
    id: number;
    atCif: string;
    nrCif: string;
    prefixDen: string;
    den: string;
}

export interface IFurnizorDto {
    atCif: string;
    nrCif: string;
    prefixDen: string;
    den: string;
}

export class FurnizoriParams {
    pageNumber = 1;
    pageSize = 10;
    searchDen: string;
    nrCif: string;
}