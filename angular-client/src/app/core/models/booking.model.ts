export interface Booking {
  workspaceId: string;
  userId: string;
  date: Date;
  startTime: string;
  endTime: string;
  status: 'pending' | 'confirmed' | 'cancelled';
}