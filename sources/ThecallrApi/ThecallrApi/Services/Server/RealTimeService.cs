using System.Collections.Generic;
using CallrApi.Objects.Misc;
using CallrApi.Objects.RealTime;

namespace CallrApi.Services.Server
{
    /// <summary>
    /// This class allows you to control phone calls in real-time.
    /// </summary>
    public class RealTimeService
    {
        /// <summary>
        /// This method makes another call, and bridges the call on answer.
        /// </summary>
        /// <param name="cdrField">Value written in the CDR.</param>
        /// <param name="cli">Outbound Caller ID.</param>
        /// <param name="ringtone">Plays music or classic ringtone (possible values are defined in <see cref="CallrApi.Enums.RealTimeRingtones"/> class).</param>
        /// <param name="targets">Phone numbers called sequentially until one answers.</param>
        /// <param name="whisper">Callee whispering Media.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Enums.RealTimeRingtones"/>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Dialout(string cdrField, string cli, string ringtone, List<Target> targets, string whisper)
        {
            RealTimeResponse response = new RealTimeResponse("dialout");
            response.Params.Add("cdr_field", cdrField);
            response.Params.Add("cli", cli);
            response.Params.Add("ringtone", ringtone);
            response.Params.Add("targets", targets);
            response.Params.Add("whisper", whisper);
            return response;
        }

        /// <summary>
        /// This method hangs up the call.
        /// </summary>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Hangup()
        {
            RealTimeResponse response = new RealTimeResponse("hangup");
            return response;
        }

        /// <summary>
        /// This method plays a Media.Library or say something with the Text-to-Speech.
        /// </summary>
        /// <param name="mediaId">Media ID or Text to say.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Play(string mediaId)
        {
            RealTimeResponse response = new RealTimeResponse("play");
            response.Params.Add("media_id", mediaId);
            return response;
        }

        /// <summary>
        /// This method plays a recording recorded with the <see cref="Record"/> command.
        /// </summary>
        /// <param name="mediaFile">Temporary file name.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        /// <seealso cref="Record"/>/>
        public RealTimeResponse PlayRecord(string mediaFile)
        {
            RealTimeResponse response = new RealTimeResponse("play_record");
            response.Params.Add("media_file", mediaFile);
            return response;
        }

        /// <summary>
        /// This method plays a Media and wait for a DTMF input at the same time.
        /// </summary>
        /// <param name="attempts">Maximum attempts. min:1 max:10.</param>
        /// <param name="maxDigits">Maximum digits. min:1 max:20.</param>
        /// <param name="mediaId">Prompt message.</param>
        /// <param name="timeoutMs">Input timeout in milliseconds. min:100 max:30000.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Read(int attempts, int maxDigits, string mediaId, int timeoutMs)
        {
            RealTimeResponse response = new RealTimeResponse("read");
            response.Params.Add("attempts", attempts);
            response.Params.Add("max_digits", maxDigits);
            response.Params.Add("media_id", mediaId);
            response.Params.Add("timeout_ms", timeoutMs);
            return response;
        }

        /// <summary>
        /// This method records the user.
        /// The recording can be stopped by pressing the hash key '#', when silence is detected, or when maximum recording duration is reached.
        /// </summary>
        /// <param name="maxDuration">(seconds) Maximum recording duration. Min:0 (disabled), Max:300.</param>
        /// <param name="silence">(seconds) Stop recording on silence. Min:0 (disabled), Max:20.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Record(int maxDuration, int silence)
        {
            RealTimeResponse response = new RealTimeResponse("record");
            response.Params.Add("max_duration", maxDuration);
            response.Params.Add("silence", silence);
            return response;
        }

        /// <summary>
        /// This method sends DTMF digits.
        /// </summary>
        /// <param name="digits">Digits to send (0-9, , #). Example : "123#".</param>
        /// <param name="durationMs">(milliseconds) Duration of each digit. Min: 1, Max: 5000.</param>
        /// <param name="timeoutMs">(milliseconds) Amount of time between tones. Min: 0, Max: 10000.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse SendDtmf(string digits, int durationMs, int timeoutMs)
        {
            RealTimeResponse response = new RealTimeResponse("send_dtmf");
            response.Params.Add("digits", digits);
            response.Params.Add("duration_ms", durationMs);
            response.Params.Add("timeout_ms", timeoutMs);
            return response;
        }

        /// <summary>
        /// This method waits for a few seconds.
        /// </summary>
        /// <param name="wait">(seconds) Time to wait. Min:1, Max: 30.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse Wait(int wait)
        {
            RealTimeResponse response = new RealTimeResponse("wait");
            response.Params.Add("wait", wait);
            return response;
        }

        /// <summary>
        /// This method waits until silence is detected, or timeout is reached.
        /// </summary>
        /// <param name="iterations">Number of times to try. Min:1, Max:10.</param>
        /// <param name="silenceMs">(milliseconds) Minimum silence duration. Min:1, Max:5000.</param>
        /// <param name="timeout">(seconds) Global timeout if silence is not detected. Min:0 (disabled), Max:300.</param>
        /// <returns><see cref="CallrApi.Objects.RealTime.RealTimeResponse" /> object representing the real-time response.</returns>
        /// <seealso cref="CallrApi.Objects.RealTime.RealTimeResponse" />
        public RealTimeResponse WaitForSilence(int iterations, int silenceMs, int timeout)
        {
            RealTimeResponse response = new RealTimeResponse("wait_for_silence");
            response.Params.Add("iterations", iterations);
            response.Params.Add("silence_ms", silenceMs);
            response.Params.Add("timeout", timeout);
            return response;
        }
    }
}
