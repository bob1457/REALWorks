export interface ManagementContract {
  id: number;
  ManagementContractTitle: string;
  StartDate: string;
  EndDate: string;
  PlacementFeeScale: string;
  ManagementFeeScale: string;
  ContractSignDate: string;
  PropertyId: number;
  ManagementContractDocUrl: string;
  ManagementContractType: number;
  IsActive: boolean;
  Notes: string;
}
