module.exports = (policy) => {
    policy.useMainline('major:', 'minor:', 'patch:');
    policy.useFormatter('majorminorpatch-pipelines-variables-and-label');
};