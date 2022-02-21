export interface IMaterial {
    id: number;
    nrPozDoc: number;
    den: string;
    cant: number;
    um: string;
    cotaTvaAch: number;
    pretAch: number;
    bazaAch: number;
    tvaAch: number;
    valAch: number;
    cotaTva: number;
    adaosProc: number;
    pret: number;
    baza: number;
    tva: number;
    val: number;
    cantUtilizata: number;
    cantRamasa: number;
    receptieId: number;
}

export interface IReceptieDtoToSave {
    nrNir: number;
    dataNir: Date;
    tipDocumentId: number;
    nrDoc: string;
    dataDoc: Date;
    obs: string;
    bazaAch: number;
    tvaAch: number;
    valAch: number;
    adaosProc: number;
    baza: number;
    tva: number;
    val: number;
    firmaId: number;
    furnizorId: number;
    materiale: IMaterial[];
}


export interface IReceptieDto {
    id: number;
    nrNir: number;
    dataNir: Date;
    tipDocumentId: number;
    nrDoc: string;
    dataDoc: Date;
    obs: string;
    bazaAch: number;
    tvaAch: number;
    valAch: number;
    adaosProc: number;
    baza: number;
    tva: number;
    val: number;
    firmaId: number;
    furnizorId: number;
    furnizor: string;
    materiale: IMaterial[];
}

export interface IReceptieInListDto {
    id: number;
    nrNir: number;
    dataNir: Date;
    furnizor: string;
    tipDocument: string;
    nrDoc: string;
    dataDoc: Date;
    bazaAch: number;
    tvaAch: number;
    valAch: number;
}

export interface IPaginationReceptie {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IReceptieInListDto[];
}

export class ReceptieParams {
    pageIndex = 1;
    pageSize = 10;
    nrDoc: string;
    furnizorId: number;
}


