import { EntityAdapter, EntityState, createEntityAdapter } from "@ngrx/entity";
import { ClaimDto } from "src/app/generated-dto/claim-dto";

export const claimAdapter: EntityAdapter<ClaimDto> = createEntityAdapter<ClaimDto>({
  selectId: (claim: ClaimDto) => claim.claimView,
});

export interface ClaimsState extends EntityState<ClaimDto> {
}

export const initialClaimState: ClaimsState = claimAdapter.getInitialState();
