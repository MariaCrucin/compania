export interface IMenuitem {
    id: string;
    text: string;
    action: string;
    icon: string;
    menuFatherId: string;
    children: any[];
    opacity: any;
    isCollapsed: any;
}
