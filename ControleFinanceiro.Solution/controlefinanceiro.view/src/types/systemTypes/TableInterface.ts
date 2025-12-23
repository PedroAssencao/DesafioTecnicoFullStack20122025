export interface tbodyItem {
  deleteFunction?: (id: string) => void;
  editFunction?: (id: string) => void;
  items: string[];
}
