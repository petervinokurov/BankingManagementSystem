import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";

export class ClaimDto {
  claimType!: string;
  claimValue!: string;
  claimView!:string;
 }

export const claimAdapter: EntityAdapter<ClaimDto> = createEntityAdapter<ClaimDto>({
  selectId: (claim: ClaimDto) => claim.claimView,
});

export interface ClaimsState extends EntityState<ClaimDto> {
}

export const initialClaimState: ClaimsState = claimAdapter.getInitialState();
