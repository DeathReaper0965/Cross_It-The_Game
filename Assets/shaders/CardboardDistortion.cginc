#if defined(CARDBOARD_DISTORTION)

float4x4  _Undistortion;
float     _MaxRadSq;
float     _NearClip;
float4x4  _RealProjection;
float4x4  _FixProjection;

float distortionFactor(float rSquared) {
	float ret = 0.0;
	ret = rSquared * (ret + _Undistortion[1][1]);
	ret = rSquared * (ret + _Undistortion[0][1]);
	ret = rSquared * (ret + _Undistortion[3][0]);
	ret = rSquared * (ret + _Undistortion[2][0]);
	ret = rSquared * (ret + _Undistortion[1][0]);
	ret = rSquared * (ret + _Undistortion[0][0]);
	return ret + 1.0;
}

// Convert point from world space to undistorted camera space.
float4 undistort(float4 pos) {
	// Go to camera space.
	pos = mul(UNITY_MATRIX_MV, pos);
	if (pos.z <= -_NearClip) {  // Reminder: Forward is -Z.
								// Undistort the point's coordinates in XY.
		float r2 = clamp(dot(pos.xy, pos.xy) / (pos.z*pos.z), 0, _MaxRadSq);
		pos.xy *= distortionFactor(r2);
	}
	return pos;
}

// Multiply by no-lens projection matrix after undistortion.
float4 undistortVertex(float4 pos) {
	return mul(_RealProjection, undistort(pos));
}

// Surface shader hides away the MVP multiplication, so we have
// to multiply by _FixProjection = inverse(MVP)*_RealProjection.
float4 undistortSurface(float4 pos) {
	return mul(_FixProjection, undistort(pos));
}

#else
// Distortion disabled.

// Just do the standard MVP transform.
float4 undistortVertex(float4 pos) {
	return mul(UNITY_MATRIX_MVP, pos);
}

// Surface shader hides away the MVP multiplication, so just return pos.
float4 undistortSurface(float4 pos) {
	return pos;
}

#endif