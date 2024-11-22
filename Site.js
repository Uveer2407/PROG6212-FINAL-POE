function confirmRejection() {
    return confirm("Are you sure you want to reject this claim?");
}

<a href="/Claims/Reject/@claim.ClaimId" onclick="return confirmRejection()">Reject</a>
