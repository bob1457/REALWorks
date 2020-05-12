import { PropertyLease, PropertyTenant } from '@lib/app-core';


export interface PropertyLeaseState {
  loading: boolean | false;
  loaded: boolean | false;
  leases: PropertyLease[] | null;
  tenants: PropertyTenant[] | null;
  // owners: PropertyOwner[] | null;
  // ownersOfProperty: PropertyOwner[] | null;
  // selectedOwner: PropertyOwner | null;
  // contracts: ManagementContract[] | null;
  // contractsForProperty: ManagementContract[] | null;
  // selectedContract: ManagementContract | null;
  errorMessage: string | null;
}
