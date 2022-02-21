export interface IServiciu {
        id: number;
        cod: string;
        den: string;
        um: string;
}

export interface IServiciuToSaveDto {
        cod: string;
        den: string;
        um: string;
}

export interface ITarifToSaveDto {
        clientId: number;
        serviciuId: number;
        pret: number;
        coefKm: number;
        procDisc: number;
}

export interface ITarif {
        id: number;
        clientId: number;
        serviciuId: number;
        cod: string;
        den: string;
        um: string;
        pret: number;
        coefKm: number;
        procDisc: number;
}
