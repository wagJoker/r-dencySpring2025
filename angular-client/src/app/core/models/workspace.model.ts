export interface Workspace {
  id: string;
  name: string;
  description: string;
  capacity: number;
  amenities: string[];
  location: string;
  available: boolean;
}