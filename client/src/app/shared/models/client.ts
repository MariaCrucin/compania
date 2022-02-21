export interface IClient {
    id: number;
    den: string;
    sediu1: string;
    sediu2: string;
    nrCont: string;
    banca: string;
    codJudJ: string;
    nrOrdJ: string;
    anJ: string;
    atCif: string;
    nrCif: string;
    numarContract: string;
    dataContract: Date;
    tara: string;
    nrTva: string;
    firmaId: number;
}

export interface IClientDto {
    id: number;
    den: string;
}