import { AuthPolicy } from '../auth/auth-policy';
import { AuthClaims } from './auth-claims';

export const AuthPolicies = {
    KanOefeningenZienPolicy: {
        requiredClaims: [
            AuthClaims.FitFlexOefeningRead,
            AuthClaims.FitFlexOefeningPrestatieRead,
            AuthClaims.FitFlexOefeningPrestatieAdd
        ]
    },
    KanOefeningenToevoegenPolicy: {
        requiredClaims: [
            AuthClaims.FitFlexOefeningAdd,
            'fuckyou'
        ]
    }
}