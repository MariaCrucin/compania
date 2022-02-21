export class MagazinParams {
    clientId = 0;
    sort = 'numar';
    pageNumber = 1;
    pageSize = 10;
    searchDen: string;
    searchNr: number;
}

export interface IMagazinImportParams {
    file: File;
    clientId: number;
}
  